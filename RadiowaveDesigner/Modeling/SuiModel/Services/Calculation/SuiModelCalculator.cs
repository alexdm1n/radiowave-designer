using System;
using System.ComponentModel;
using RadiowaveDesigner.Modeling.SuiModel.Constants;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.SuiModel.Services.Calculation;

[Description(
    "Formula: L = A + 10*y*log(d/d0) + Xf + Xh")]
internal class SuiModelCalculator : ISuiModelCalculator
{
    public int CalculatePropagationRange(BaseStationConfiguration config)
    {
        var log1 =
            (SuiModelConstatnts.NormalLossInDb -
             CalculateTermA() -
             CalculateCoefficientXf(config.FrequencyInMHz * 1000) -
             CalculateCoefficientXh()) /
            (10 * CalculateTermY(config.Height)); // log(d/d0)
        var logD = log1 + Double.Log10(SuiModelConstatnts.BaseDistanceInMeters); // log(d)
        var resultInKilometers = Math.Pow(10, logD);
        return Convert.ToInt32(resultInKilometers * 1000);
    }

    private static double CalculateTermA()
    {
        return 20 * Double
            .Log10(4 * Double.Pi * SuiModelConstatnts.BaseDistanceInMeters / RadiowaveConstants.WaveLengthInMeters);
    }

    private static double CalculateTermY(int baseStationHeight)
    {
        return TerrainTypeConstants.TerrainTypeB.ParameterA -
               TerrainTypeConstants.TerrainTypeB.ParameterB * baseStationHeight +
               TerrainTypeConstants.TerrainTypeB.ParameterC / baseStationHeight;
    }

    private static double CalculateCoefficientXf(int frequencyInHz)
    {
        return frequencyInHz < 2500000 ? 0 : 6 * Double.Log10(frequencyInHz / 2000);
    }

    private static double CalculateCoefficientXh()
    {
        return -10.8 * Double.Log10(SuiModelConstatnts.ReceiverHeightInMeters / 2000);
    }
}