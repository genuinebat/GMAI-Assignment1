using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssassinBot;

public class AssassinBotFSM : MonoBehaviour
{
    FSM<string> fsm;
    FSMState<string> idleState, prepareState, resupplyState, searchState;

    public enum Arsenal { None, Knife, Gun };
    public Arsenal Weapon { get; set; }

    public int DisguiseCount, InvisCount, DecoyCount;

    public AssassinBotFSM()
    {
        DisguiseCount = 0;
        InvisCount = 0;
        DecoyCount = 0;

        Weapon = Arsenal.None;
    }

    void Start()
    {
        fsm = new FSM<string>();

        idleState = new IdleState(fsm);
        prepareState = new PrepareState(fsm, this);
        resupplyState = new ResupplyState(fsm, this);
        searchState = new SearchState(fsm, this);

        fsm.AddState(idleState);
        fsm.AddState(prepareState);
        fsm.AddState(resupplyState);
        fsm.AddState(searchState);

        fsm.SetState("Idle");
    }

    void Update()
    {
        fsm.Update();
    }
}