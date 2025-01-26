using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSignatureHandler : MonoBehaviour
{
    private Animator anima;

    public void Awake()
    {
        anima = GetComponent<Animator>();
    }

    public static TeamSignatureHandler CreateSignature(bool isCrosses)
    {
        var signaturePrefab = Resources.Load<TeamSignatureHandler>("TeamSignature");

        var signature = Instantiate(signaturePrefab);
        signature.Init(isCrosses, 3);

        return signature;
    }

    public void Init(bool isCrosses, int signatureIndex)
    {
        anima.SetBool("IsCrosses", isCrosses);
        anima.SetInteger("SignatureType", signatureIndex);

        anima.Play("BaseState");
    }
}
