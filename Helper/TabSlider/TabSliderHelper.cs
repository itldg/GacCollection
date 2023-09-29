/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 标签滑动器辅助类
 *
 * Statement : Open Source
 * 
 * /////////////////////////////////////////////////////////////////////
 * Modifiy History
 * 
 * Date    :
 * Resume  :
 * 
 */
using System;
using System.Reflection;
using System.Windows.Forms;
namespace Hweny.TabSlider
{
    internal static class TabSliderHelper
    {
        public static void CreateControls(Control control)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            MethodInfo method = control.GetType().GetMethod("CreateControl", bindingFlags);
            method.Invoke(control, new object[] { true });
            foreach (Control subCtl in control.Controls)
            {
                CreateControls(subCtl);
            }
        }
    }
}
