#include <FastLED.h>
class ColorManager
{
public:
    CRGBPalette16 currentPalette;
    CRGB currentSingle;
    uint8_t state;
    uint8_t maxBrightness;
    uint8_t needSmooth;
    ColorManager()
    {
        currentPalette = PartyColors_p;
        currentSingle = CRGB(10, 10, 10);
        state = 0;
        needSmooth = 0;
        maxBrightness = 128;
    };
    void SetupPalettePreset(uint8_t c1, uint8_t c2, uint8_t c3, uint8_t c4);
    void SetupPaletteFourColor(CRGB color1, CRGB color2, CRGB color3, CRGB color4);
    void SmoothChange(CRGB *L, uint16_t N);
    void SmoothChangePalette(CRGB *L, uint16_t N, uint8_t colorIndex);
    void SetupPaletteRedPink();
};