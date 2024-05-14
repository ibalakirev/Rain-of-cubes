using TMPro;
using UnityEngine;

public class ObjectsInfoView : MonoBehaviour
{
    [SerializeField] private Spawner�ubes _spawner�ubes;
    [SerializeField] private SpawnerBombs _spawnerBombs;
    [SerializeField] private TextMeshProUGUI _textQuantityCubesActive;
    [SerializeField] private TextMeshProUGUI _textQuantityCubesCreated;
    [SerializeField] private TextMeshProUGUI _textQuantityBombsActive;
    [SerializeField] private TextMeshProUGUI _textQuantityBombsCreated;


    private void OnEnable()
    {
        _spawner�ubes.ActiveObjectsCounted += ShowQuantityCubesActive;
        _spawner�ubes.ObjectCreated += ShowQuantityCubesCreated;

        _spawnerBombs.ActiveObjectsCounted += ShowQuantityBombsActive;
        _spawnerBombs.ObjectCreated += ShowQuantityBombsCreated;
    }

    private void OnDisable()
    {
        _spawner�ubes.ActiveObjectsCounted -= ShowQuantityCubesActive;
        _spawner�ubes.ObjectCreated -= ShowQuantityCubesCreated;

        _spawnerBombs.ActiveObjectsCounted -= ShowQuantityBombsActive;
        _spawnerBombs.ObjectCreated -= ShowQuantityBombsCreated;

    }

    private void ShowQuantityCubesActive()
    {
        string name = "���������� �������� �����";

        _textQuantityCubesActive.text = $"{name}: {_spawner�ubes.QuantityObjectsActive}";
    }

    private void ShowQuantityCubesCreated()
    {
        string name = "���������� ��������� �����";

        _textQuantityCubesCreated.text = $"{name}: {_spawner�ubes.QuantityObjectsCreated}";
    }

    private void ShowQuantityBombsActive()
    {
        string name = "���������� �������� ����";

        _textQuantityBombsActive.text = $"{name}: {_spawnerBombs.QuantityObjectsActive}";
    }

    private void ShowQuantityBombsCreated()
    {
        string name = "���������� ��������� ����";

        _textQuantityBombsCreated.text = $"{name}: {_spawnerBombs.QuantityObjectsCreated}";
    }
}
