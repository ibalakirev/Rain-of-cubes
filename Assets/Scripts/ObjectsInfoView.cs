using TMPro;
using UnityEngine;

public class ObjectsInfoView : MonoBehaviour
{
    [SerializeField] private SpawnerСubes _spawnerСubes;
    [SerializeField] private SpawnerBombs _spawnerBombs;
    [SerializeField] private TextMeshProUGUI _textQuantityCubesActive;
    [SerializeField] private TextMeshProUGUI _textQuantityCubesCreated;
    [SerializeField] private TextMeshProUGUI _textQuantityBombsActive;
    [SerializeField] private TextMeshProUGUI _textQuantityBombsCreated;


    private void OnEnable()
    {
        _spawnerСubes.ActiveObjectsCounted += ShowQuantityCubesActive;
        _spawnerСubes.ObjectCreated += ShowQuantityCubesCreated;

        _spawnerBombs.ActiveObjectsCounted += ShowQuantityBombsActive;
        _spawnerBombs.ObjectCreated += ShowQuantityBombsCreated;
    }

    private void OnDisable()
    {
        _spawnerСubes.ActiveObjectsCounted -= ShowQuantityCubesActive;
        _spawnerСubes.ObjectCreated -= ShowQuantityCubesCreated;

        _spawnerBombs.ActiveObjectsCounted -= ShowQuantityBombsActive;
        _spawnerBombs.ObjectCreated -= ShowQuantityBombsCreated;

    }

    private void ShowQuantityCubesActive()
    {
        string name = "Количество активных кубов";

        _textQuantityCubesActive.text = $"{name}: {_spawnerСubes.QuantityObjectsActive}";
    }

    private void ShowQuantityCubesCreated()
    {
        string name = "Количество созданных кубов";

        _textQuantityCubesCreated.text = $"{name}: {_spawnerСubes.QuantityObjectsCreated}";
    }

    private void ShowQuantityBombsActive()
    {
        string name = "Количество активных бомб";

        _textQuantityBombsActive.text = $"{name}: {_spawnerBombs.QuantityObjectsActive}";
    }

    private void ShowQuantityBombsCreated()
    {
        string name = "Количество созданных бомб";

        _textQuantityBombsCreated.text = $"{name}: {_spawnerBombs.QuantityObjectsCreated}";
    }
}
