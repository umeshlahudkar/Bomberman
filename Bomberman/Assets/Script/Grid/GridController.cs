using System.Collections.Generic;
using UnityEngine;
using Bomberman.Global;

namespace Bomberman.Grid
{
    public class GridController : GenericSingleton<GridController>
    {
        [SerializeField] private GameObject destructablePrefab;
        [SerializeField] private GameObject nonDestructablePrefab;
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject groundPrefab;

        [SerializeField] private int destructibleCount;
        private List<Vector3> emptyPositions = new List<Vector3>();

        private int width = 15;
        private int height = 11;
        private float offset = 0.7f;

        protected override void Awake()
        {
            base.Awake();
            CreateGameField();
        }

        private void CreateGameField()
        {
            InstantiateGameField();
            InstantiateDestructibleObject(destructibleCount);
        }

        private void InstantiateGameField()
        {
            for (int x = -1; x <= width; x++)
            {
                for (int y = -1; y <= height; y++)
                {
                    // Instantiate Boundry wall
                    if (x == -1 || y == -1 || x == width || y == height)
                    {
                        GameObject wall = Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
                        continue;
                    }

                    if (x >= 0 && y >= 0 && x < width && y < height)
                    {
                        // Instantiate ground in the given range
                        GameObject ground = Instantiate(groundPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);

                        // Instantiating Non-Destructible Objects
                        if (x % 2 != 0 && y % 2 != 0)
                        {
                            GameObject nonDestructibleObject = Instantiate(nonDestructablePrefab, new Vector3(x, offset, y), Quaternion.identity, transform);
                            continue;
                        }

                        // Storing the empty position to instantiate Destructible object, enemys and Player
                        // neglecting positions near the player position.
                        if (x >= 0 && x <= 3 && y >= 7 && y <= 10) continue;
                        emptyPositions.Add(new Vector3(x, offset, y));
                    }
                }
            }
        }

        // Instantiate destructible Object at the empty position and removes the empty position from the list
        private void InstantiateDestructibleObject(int value)
        {
            for (int x = 0; x < value; x++)
            {
                int randomIndex = GetRandomNumber(emptyPositions.Count);
                Vector3 newPosition = emptyPositions[randomIndex];
                GameObject destructibleObject = Instantiate(destructablePrefab, newPosition, Quaternion.identity, transform);
                emptyPositions.RemoveAt(randomIndex);
            }
        }

        private int GetRandomNumber(int value)
        {
            return Random.Range(0, value);
        }

        public Vector3 GetEmptyPosition()
        {
            int index = GetRandomNumber(emptyPositions.Count);
            Vector3 newPosition = emptyPositions[index];
            emptyPositions.RemoveAt(index);
            return newPosition;
        }

    }
}

