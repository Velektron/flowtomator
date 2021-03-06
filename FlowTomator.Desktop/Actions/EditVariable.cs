﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlowTomator.Common;

namespace FlowTomator.Desktop
{
    public class EditVariableAction : Action
    {
        public VariableInfo VariableInfo { get; private set; }
        public Variable OldLink { get; private set; }
        public object OldValue { get; private set; }
        public object NewValue { get; private set; }

        public EditVariableAction(VariableInfo variableInfo, object newValue)
        {
            VariableInfo = variableInfo;
            OldLink = variableInfo.Variable.Linked;
            OldValue = variableInfo.Value;
            NewValue = newValue;
        }

        public override void Do()
        {
            VariableInfo.Variable.Link(null);
            VariableInfo.Variable.Value = NewValue;
            VariableInfo.Update();
        }

        public override void Undo()
        {
            if (OldLink != null)
                VariableInfo.Variable.Link(OldLink);
            else
                VariableInfo.Variable.Value = OldValue;

            VariableInfo.Update();
        }
    }
}