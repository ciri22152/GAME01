using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition; // ���̈ʒu��ۑ�
    private Transform originalParent; // ���̐e�I�u�W�F�N�g��ۑ�
    private Canvas canvas; // �h���b�O���̕`��ɕK�v��Canvas

    private void Start()
    {
        // �J�[�h��`�悷��Canvas���擾�i�h���b�O���̈ʒu�����ɕK�v�j
        canvas = GetComponentInParent<Canvas>();
    }

    // �h���b�O�J�n���̏���
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.localPosition; // ���̈ʒu���L�^
        originalParent = transform.parent; // ���̐e���L�^

        // �h���b�O����Canvas�̈�ԏ�ɕ`�悳���悤�ɐe��ύX
        transform.SetParent(canvas.transform);
    }

    // �h���b�O���̏���
    public void OnDrag(PointerEventData eventData)
    {
        // �}�E�X�̈ʒu�ɒǏ]������iScreenPoint��WorldPoint�ɕϊ��j
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out Vector3 worldPoint
        );

        transform.position = worldPoint; // �J�[�h���}�E�X�ʒu�Ɉړ�
    }

    // �h���b�v���̏���
    public void OnEndDrag(PointerEventData eventData)
    {
        // Raycast�Ńh���b�v������m
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // �h���b�v�悪DropZone�^�O�����I�u�W�F�N�g���ǂ������m�F
            if (hit.collider.CompareTag("DropZone"))
            {
                // �h���b�v���Transform���擾
                Transform dropZone = hit.collider.transform;

                // �J�[�h���h���b�v�]�[���ɃX�i�b�v
                transform.SetParent(dropZone);
                transform.localPosition = Vector3.zero;

                // �h���b�v��̃T�C�Y�ɍ��킹�ăX�P�[���𒲐�
                RectTransform dropZoneRect = dropZone.GetComponent<RectTransform>();
                RectTransform cardRect = GetComponent<RectTransform>();

                if (dropZoneRect != null && cardRect != null)
                {
                    Vector2 dropZoneSize = dropZoneRect.sizeDelta; // �h���b�v�]�[���̃T�C�Y���擾
                    Vector2 cardSize = cardRect.sizeDelta; // �J�[�h�̌��T�C�Y���擾

                    // �X�P�[�����v�Z���ēK�p
                    float scaleX = dropZoneSize.x / cardSize.x;
                    float scaleY = dropZoneSize.y / cardSize.y;
                    float uniformScale = Mathf.Min(scaleX, scaleY); // �c������ێ����邽�ߏ����������̗p
                    transform.localScale = new Vector3(uniformScale, uniformScale, 1f);
                }

                return;
            }
        }

        // �h���b�v�悪�s���ȏꍇ�A���̈ʒu�ɖ߂�
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;
    }
}
