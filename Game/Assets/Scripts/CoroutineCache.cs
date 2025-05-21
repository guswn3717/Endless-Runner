using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
   static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();

   public static WaitForSeconds WaitForSecond(float time)
   {
      WaitForSeconds waitForSeconds;

      if (dictionary.TryGetValue(timem, out waitForSeconds))
      {
         
      }
   }
}
