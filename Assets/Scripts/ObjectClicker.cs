using Assets.Blocks;
using Assets.Scripts;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    private Block lastClickedBlock;
    private bool isClicked;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    CheckAndClickBlock(hit);
                    CheckAndClickArrow(hit);
                }
            }
        }
    }
    private void CheckAndClickBlock(RaycastHit hit)
    {
        Block block = GameField.TryFindBlock(hit.transform.position);
        if (block != null)
        {
            if ((lastClickedBlock!=null)&&
                (block.CoordinateOnBoard == lastClickedBlock.CoordinateOnBoard))
            {
                if (isClicked)
                {
                    Draw.HideArrows();
                    isClicked = false;
                }
                else
                {
                    block.ReactionOnClick();
                    isClicked = true;
                }
            }
            else
            {
                block.ReactionOnClick();
                lastClickedBlock = block;
                isClicked = true;
            }
        }
    }
    private void CheckAndClickArrow(RaycastHit hit)
    {
        Arrow arrow = GameField.TryFindArrow(hit.transform.position);
        if ((arrow != null) && (arrow.isActive))
        {
            Direction dir = DefineDirection(arrow.arrow.transform.position);
            GameField.SwapBlocks(lastClickedBlock, dir);
        }
    }
    private Direction DefineDirection(Vector2 positionArrow)
    {
        float innacuraccy = 0.01f;
        if ((positionArrow.x > lastClickedBlock.Object.transform.position.x) &&
         (Mathf.Abs(positionArrow.y)+innacuraccy>Mathf.Abs(lastClickedBlock.Object.transform.position.y))&&
         (Mathf.Abs(positionArrow.y) - innacuraccy < Mathf.Abs(lastClickedBlock.Object.transform.position.y)))
        {
            return Direction.Right;
        }
        if ((positionArrow.x < lastClickedBlock.Object.transform.position.x) &&
                 (Mathf.Abs(positionArrow.y) + innacuraccy > Mathf.Abs(lastClickedBlock.Object.transform.position.y)) &&
         (Mathf.Abs(positionArrow.y) - innacuraccy < Mathf.Abs(lastClickedBlock.Object.transform.position.y)))
        {
            return Direction.Left;
        }
        if ((Mathf.Abs(positionArrow.x) + innacuraccy > Mathf.Abs(lastClickedBlock.Object.transform.position.x))&&
            (Mathf.Abs(positionArrow.x)- innacuraccy < Mathf.Abs(lastClickedBlock.Object.transform.position.x)&&
                (positionArrow.y > lastClickedBlock.Object.transform.position.y)))
        {
            return Direction.Up;
        }
        if ((Mathf.Abs(positionArrow.x) + innacuraccy > Mathf.Abs(lastClickedBlock.Object.transform.position.x)) &&
         (Mathf.Abs(positionArrow.x) - innacuraccy < Mathf.Abs(lastClickedBlock.Object.transform.position.x)&&
            (positionArrow.y <lastClickedBlock.Object.transform.position.y)))
        {
            return Direction.Down;
        }
        return Direction.Undefined;
    }
}
