using UnityEngine;

public class CharacterSpritesController : MonoBehaviour
{
    // PARAMS 

    [SerializeField]
    private bool enable;
    [SerializeField]
    private PlayerController playerController;

    // ----- Sprites -----
    // Idle
    [Space]
    [SerializeField]
    Sprite idleFrontSprite;
    [SerializeField]
    Sprite idleRightSprite;
    [SerializeField]
    Sprite idleBackSprite;
    [SerializeField]
    Sprite idleLeftSprite;

    // Walk
    // F
    [Space]
    [SerializeField]
    Sprite walkFrontSprite1;
    [SerializeField]
    Sprite walkFrontSprite2;
    // R
    [Space]
    [SerializeField]
    Sprite walkRightSprite1;
    [SerializeField]
    Sprite walkRightSprite2;
    // B
    [Space]
    [SerializeField]
    Sprite walkBackSprite1;
    [SerializeField]
    Sprite walkBackSprite2;
    // L
    [Space]
    [SerializeField]
    Sprite walkLeftSprite1;
    [SerializeField]
    Sprite walkLeftSprite2;

    // PRIVATE

    private SpriteRenderer _rd;
    private Sprite _currentSprite;

    public Sprite CurrentSprite
    {
        get { return _currentSprite; }
        set
        {
            _currentSprite = value;
            _rd.sprite = _currentSprite;
        }
    }
    private Sprite[] idleSprites;
    private Sprite[][] walkSprites;

    // ENUM

    enum Side
    {
        Bottom,
        Right,
        Front,
        Left
    }

    // UNITY

    private void Awake()
    {
        _rd = GetComponent<SpriteRenderer>();
        CurrentSprite = idleRightSprite;

        idleSprites = new Sprite[]
        {
            idleBackSprite,
            idleRightSprite,
            idleFrontSprite,
            idleLeftSprite
        };

        walkSprites = new Sprite[][]
        {
            new Sprite[] {
                walkBackSprite1,
                walkBackSprite2
            },
            new Sprite[] {
                walkRightSprite1,
                walkRightSprite2
            },
            new Sprite[] {
                walkFrontSprite1,
                walkFrontSprite2
            },
            new Sprite[] {
                walkLeftSprite1,
                walkLeftSprite2
            },
        };
    }

    private void OnEnable()
    {
        PlayerInputs.instance.onStopMove += OnIdle;
    }

    private void OnDisable()
    {
        PlayerInputs.instance.onStopMove -= OnIdle;
    }

    private void Update()
    {
        if (playerController.IsMoving)
        {
            int index = GetIndexFromCharacterRotation();
            CurrentSprite = GetWalkSprite(index);
        }
    }

    // INTERNAL

    private int GetIndexFromCharacterRotation()
    {
        float adjustedRot = (transform.parent.transform.eulerAngles.y + 45f) % 360f;
        int directionIndex = Mathf.FloorToInt(adjustedRot / 90f);
        Debug.Log(directionIndex);

        return directionIndex;
    }

    private Sprite GetIdleSprite(int index)
    {
        if (index < 0 || index >= idleSprites.Length)
            return idleSprites[0];

        return idleSprites[index];
    }

    private Sprite GetWalkSprite(int index, int frame = 0)
    {
        if (index < 0 || index >= walkSprites.Length)
            return walkSprites[0][0];

        return walkSprites[index][frame];
    }

    private void OnIdle()
    {
        int index = GetIndexFromCharacterRotation();
        CurrentSprite = GetIdleSprite(index);
    }
}
