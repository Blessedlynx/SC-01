using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullTeam : Team
{
    public static NullTeam Instance => instance == null ? instance = new NullTeam() : instance;

    private static NullTeam instance;

    private NullTeam() : base("NullTeam", false) { }
}
