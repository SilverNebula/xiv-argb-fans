#include <FastLED.h>
#include <HardwareSerial.h>
#include "color_manager.h"
#define LED_PIN1 7
#define LED_PIN2 6
#define NUM_LEDS 8
#define NUM_GROUPS 2
#define MAXBRIGHTNESS 128
#define UPDATES_PER_SECOND 30

CRGB colors[2][NUM_LEDS];
ColorManager colorManager[2];
void setup()
{
  Serial.begin(4800);
  // SetupPalette();
  delay(3000);
  // put your setup code here, to run once:
  for (uint8_t i = 0; i < 2; i++)
  {
    init_group(i);
  }
  FastLED.setBrightness(MAXBRIGHTNESS);
  FastLED.show();
}
void init_group(uint8_t index)
{
  // uint8_t pin = LED_PIN[index];
  CRGB *target = colors[index];
  switch (index)
  {
  case 0:
  {
    FastLED.addLeds<WS2812B, LED_PIN1, GRB>(target, NUM_LEDS);
    break;
  }
  case 1:
  {
    FastLED.addLeds<WS2812B, LED_PIN2, GRB>(target, NUM_LEDS);
    break;
  }
  }
  target[0] = CRGB(120, 120, 120);
  target[1] = CRGB(60, 60, 60);
  target[2] = CRGB(50, 50, 50);
  target[3] = CRGB(10, 10, 10);
  target[4] = CRGB(3, 3, 3);
  target[5] = CRGB(2, 2, 2);
  target[6] = CRGB(1, 1, 1);
  target[7] = CRGB(00, 00, 00);
  return;
}
uint8_t current_state = 0;
uint8_t solve_console()
{
  uint8_t str[5];
  String reply = "";
  uint8_t cnt = 0;
  while (Serial.available() > 0)
  {
    str[cnt] = int(Serial.read());
    reply += String(str[cnt], 10);
    reply += '|';
    cnt++;
    delay(10);
  }
  Serial.print(reply);
  uint8_t res = 0;
  uint8_t flag = ((char)str[0]);
  uint8_t target = flag & 15;
  flag >>= 4;
  // TODO:状态压缩
  for (uint8_t i = 0; i < NUM_GROUPS; i++)
  {
    if (target == 15 || i == target)
    {
      colorManager[i].state = flag;
      if (flag == 0)
      {
        colorManager[i].needSmooth = 20;
        colorManager[i].currentSingle = CRGB(10, 10, 10);
      }
      if (flag == 1)
      {
        colorManager[i].needSmooth = 20;
        colorManager[i].SetupPalettePreset(str[1], str[2], str[3], str[4]);
      }
      if (flag == 2)
      {
        colorManager[i].needSmooth = 20;
        colorManager[i].currentSingle = CRGB(str[1], str[2], str[3]);
      }
    }
  }
  return res;
}
void loop()
{
  if (Serial.available() > 0)
  {
    current_state = solve_console();
  }
  for (uint8_t i = 0; i < NUM_GROUPS; i++)
  {
    switch (colorManager[i].state)
    {
    case 0:
    {
      style_normal(i);
      break;
    }
    case 1:
    {
      style_active(i);
      break;
    }
    case 2:
    {
      style_single(i);
      break;
    }
    }
  }
  FastLED.show();
  FastLED.delay(1000 / UPDATES_PER_SECOND);
}
void style_normal(uint8_t index)
{
  if (colorManager[index].needSmooth > 0)
  {
    colorManager[index].needSmooth--;
    colorManager[index].SmoothChange(colors[index], NUM_LEDS);
  }
  else
  {
    for (int i = 0; i < NUM_LEDS; i++)
    {
      colors[index][i] = CRGB(10, 10, 10);
    }
  }
}
void style_active(uint8_t index)
{
  static uint8_t startIndex = 0;
  if (colorManager[index].needSmooth > 0)
  {
    colorManager[index].needSmooth--;
    colorManager[index].SmoothChangePalette(colors[index], NUM_LEDS, startIndex);
    startIndex++;
  }
  else
  {
    startIndex = startIndex + 1; /* motion speed */
    CRGB *target = colors[index];
    FillLEDsFromPaletteColors(target, startIndex, index);
  }
}
void style_single(uint8_t index)
{
  if (colorManager[index].needSmooth > 0)
  {
    colorManager[index].needSmooth--;
    colorManager[index].SmoothChange(colors[index], NUM_LEDS);
  }
  else
  {

    for (int i = 0; i < NUM_LEDS; i++)
    {
      colors[index][i] = CRGB(colorManager[index].currentSingle);
    }
  }
}
void FillLEDsFromPaletteColors(CRGB *target, uint8_t colorIndex, uint8_t manager_index)
{
  uint8_t brightness = MAXBRIGHTNESS;
  for (int i = 0; i < NUM_LEDS; i++)
  {
    target[i] = ColorFromPalette(colorManager[manager_index].currentPalette, colorIndex, brightness, LINEARBLEND);
    colorIndex += 3;
  }
}
