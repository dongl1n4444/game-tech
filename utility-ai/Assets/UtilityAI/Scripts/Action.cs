using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Utility
{
    public abstract class Action : ScriptableObject
    {
        public Precondition[] preconditions;
        public Consideration[] considerations;

        public abstract System.Type ActionObjType();
    }
}
