using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    private readonly Dictionary<EPuzzleCategories, string> _puzzleCatDirectory = new Dictionary<EPuzzleCategories, string>();
    private int _settings;
    private const int SettingsNumber = 2;
    private bool _muteFxPermanently = false;

    public enum EPairNumber
    {
        NotSet=0,
        E10Pairs=10,
        E15Pairs = 15,
        E20Pairs = 20,
    }

    public enum EPuzzleCategories
    {
        NotSet,
        Fruits,
        Vegetables
    }

    public struct Settings
    {
        public EPairNumber PairsNumber;
        public EPuzzleCategories PuzzleCategory;
    }

    private Settings _gameSetting;
    public static GameSettings Instance;

    private void Awake()
    {
        if (Instance==null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }

    void Start()
    {
        SetPuzzleCatDirectory();
        _gameSetting = new Settings();
        ResetGameSettings();
    }

    private void SetPuzzleCatDirectory()
    {
        _puzzleCatDirectory.Add(EPuzzleCategories.Fruits, "Fruits");
        _puzzleCatDirectory.Add(EPuzzleCategories.Vegetables, "Vegetables");
    }

    public void SetPairNumber(EPairNumber Number)
    {
        if (_gameSetting.PairsNumber == EPairNumber.NotSet)
        {
            _settings++;
        }
        _gameSetting.PairsNumber = Number;
    }    

    public void SetPuzzleCategories(EPuzzleCategories cat)
    {
        if (_gameSetting.PuzzleCategory == EPuzzleCategories.NotSet)
        {
            _settings++;
        }
        _gameSetting.PuzzleCategory = cat;
    }

    public EPairNumber GetEPairNumber()
    {
        return _gameSetting.PairsNumber;
    }

    public EPuzzleCategories GetEPuzzleCategories()
    {
        return _gameSetting.PuzzleCategory;
    }

    public void ResetGameSettings()
    {
        _settings = 0;
        _gameSetting.PuzzleCategory = EPuzzleCategories.NotSet;
        _gameSetting.PairsNumber = EPairNumber.NotSet;
    }

    public bool AllSettingsReady()
    {
        return _settings == SettingsNumber;
    }

    public string GetMaterialDirectoryName()
    {
        return "Materials/";
    }

    public string GetPuzzleCategoryTextureDirectoryName()
    {

        if (_puzzleCatDirectory.ContainsKey(_gameSetting.PuzzleCategory))
        {
            return "Graphics/PuzzleCat/"+_puzzleCatDirectory[_gameSetting.PuzzleCategory]+"/";
        }
        else
        {
            Debug.LogError("ERROR: CANNOT GET DİRECTORY NAME");
            return "";
        }
        
    }

    public void MuteSoundEffectPermanently(bool muted)
    {
        _muteFxPermanently = muted;
    }

    public bool IsSoundEffectMutedPermanently()
    {
        return _muteFxPermanently;
    }

}
