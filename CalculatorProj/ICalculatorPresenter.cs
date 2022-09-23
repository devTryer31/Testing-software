using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProj
{
    public interface ICalculatorPresenter
    {
        ///<summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '+'
        ///</summary>
        void OnPlusClicked();

        ///<summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '-'
        ///</summary>
        void OnMinusClicked();

        ///<summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '/'
        ///</summary>
        void OnDivideClicked();

        ///<summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '*'
        ///</summary>
        void OnMultiplyClicked();
    }
}
