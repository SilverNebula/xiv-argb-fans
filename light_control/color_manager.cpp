#include "color_manager.h"

CRGBPalette16 presetColors = {
    CRGB(0xFF9B10), //金色
    CRGB(0xAF6030), //亮银
    CRGB(0x66CCFF), //浅蓝
    CRGB(0x3399FF), //天蓝
    CRGB(0xFF0505), //玫红
    CRGB(0xAF3333), //粉红
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
    CRGB(0x1F1F1F),
};

void ColorManager::SetupPaletteFourColor(CRGB color1, CRGB color2, CRGB color3, CRGB color4)
{
    CRGB array[16];
    for (int i = 0; i < 16; i += 4)
    {
        array[i] = color1;
        array[i + 1] = color2;
        array[i + 2] = color3;
        array[i + 3] = color4;
    }
    this->currentPalette = CRGBPalette16(array);
}

void ColorManager::SmoothChange(CRGB *L, uint16_t N)
{
    for (int i = 0; i < N; i++)
    {
        L[i] = L[i].lerp8(this->currentSingle, 64);
    }
}
void ColorManager::SmoothChangePalette(CRGB *L, uint16_t N, uint8_t colorIndex)
{
    for (int i = 0; i < N; i++)
    {
        L[i] = L[i].lerp8(
            ColorFromPalette(this->currentPalette, colorIndex, this->maxBrightness, LINEARBLEND),
            64);
        colorIndex += 3;
    }
}

void ColorManager::SetupPaletteRedPink()
{
    CRGB red = CHSV(HUE_RED, 255, 255);
    CRGB pink = CHSV(HUE_PINK, 255, 255);
    CRGB black = CRGB::Black;

    this->currentPalette = CRGBPalette16(
        red, black, pink, black,
        red, black, pink, black,
        red, black, pink, black,
        red, black, pink, black);
}

void ColorManager::SetupPalettePreset(uint8_t c1, uint8_t c2, uint8_t c3, uint8_t c4)
{
    // SetupPaletteFourColor(
    //     RainbowColors_p[c1],
    //     RainbowColors_p[c2],
    //     RainbowColors_p[c3],
    //     RainbowColors_p[c4]);
    SetupPaletteFourColor(
        presetColors[c1],
        presetColors[c2],
        presetColors[c3],
        presetColors[c4]);
    return;
}