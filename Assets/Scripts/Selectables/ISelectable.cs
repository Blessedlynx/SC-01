using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    public Point GetPoint();

    public bool TryInteract(Selector sourceSelector);
}
