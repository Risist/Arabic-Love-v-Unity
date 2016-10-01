using UnityEngine;
using System.Collections;

public class AcceptBuildManager : MonoBehaviour {

    enum State
    {
        unsolved,
        accepted,
        declined
    }
    State state;

    public bool isAccepted()
    {
        return state == State.accepted;
    }
    public bool isDeclined()
    {
        return state == State.declined;
    }
    public void resetState()
    {
        state = State.unsolved;
    }

	
	
	public void onButtonAccept()
    {
        if(state == State.unsolved)
        {
            state = State.accepted;
        }
    }

    public void onButtonDecline()
    {
        if (state == State.unsolved)
        {
            state = State.declined;
        }
    }
}
