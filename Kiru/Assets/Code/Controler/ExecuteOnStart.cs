using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kiru {
    public class ExecuteOnStart : MonoBehaviour {
        [SerializeField] ICommand _command = null;

        void Start() {
            _command.Execute();
        }
    }
}
