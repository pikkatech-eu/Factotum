/***********************************************************************************
* File:         KeyboardLayoutManager.cs                                           *
* Contents:     Class KeyboardLayoutManager                                        *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu) & ChatGPT     *
* Date:         2025-11-19 14:39                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Runtime.InteropServices;

/// <summary>
/// Performs switch to a local windows keyboard.
/// </summary>
public static class KeyboardLayoutManager
{
	#region Constants
	private const uint KLF_ACTIVATE = 0x00000001;
	#endregion

	#region Interop
	[DllImport("user32.dll")] 
    private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

    [DllImport("user32.dll")] 
    private static extern IntPtr ActivateKeyboardLayout(IntPtr hkl, uint Flags);

    [DllImport("user32.dll")]
    private static extern int GetKeyboardLayoutList(int nBuff, [Out] IntPtr[] lpList);
	#endregion

	/// <summary>
	/// Returns true if a keyboard layout HKL (hex string) is installed.
	/// </summary>
	/// <param name="layoutId">HKL code of the keyboard.</param>
	/// <returns>True, if the keyboard is installed.</returns>
    public static bool IsLayoutInstalled(string layoutId)
    {
        int count		= GetKeyboardLayoutList(0, null);
        IntPtr[] list	= new IntPtr[count];
        GetKeyboardLayoutList(count, list);

        return list.Any(hkl => hkl.ToInt64().ToString("X8").EndsWith(layoutId.Substring(4)));
    }

	/// <summary>
	/// Loads and activates an HKL for the current thread.
	/// </summary>
	/// <param name="layoutId">HKL code of the keyboard.</param>
	/// <returns>True if switch has succeeded.</returns>
    public static bool SwitchTo(string layoutId)
    {
        IntPtr hkl = LoadKeyboardLayout(layoutId, KLF_ACTIVATE);

        if (hkl == IntPtr.Zero)
		{
			return false;
		}

        return ActivateKeyboardLayout(hkl, KLF_ACTIVATE) != IntPtr.Zero;
    }
}
