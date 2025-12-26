using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                CallEventOnInteractCounter();
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {
            // There is a KitchenObject here
            if (!player.HasKitchenObject())
            {
                // Player is carrying something
                CallEventOnInteractCounter();
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
            else
            {
                // layer not carrying anything
            }
        }
    }
}
