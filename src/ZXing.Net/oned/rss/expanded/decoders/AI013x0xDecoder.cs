﻿/*
 * Copyright (C) 2010 ZXing authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/*
 * These authors would like to acknowledge the Spanish Ministry of Industry,
 * Tourism and Trade, for the support in the project TSI020301-2008-2
 * "PIRAmIDE: Personalizable Interactions with Resources on AmI-enabled
 * Mobile Dynamic Environments", led by Treelogic
 * ( http://www.treelogic.com/ ):
 *
 *   http://www.piramidepse.com/
 */

using System;
using System.Text;
using Auki.Barcode.Common;

namespace Auki.Barcode.OneD.RSS.Expanded.Decoders
{
   /// <summary>
   /// <author>Pablo Orduña, University of Deusto (pablo.orduna@deusto.es)</author>
   /// </summary>
   abstract class AI013x0xDecoder : AI01weightDecoder
   {
      private static int HEADER_SIZE = 4 + 1;
      private static int WEIGHT_SIZE = 15;

      internal AI013x0xDecoder(BitArray information)
         : base(information)
      {
      }

      override public String parseInformation()
      {
         if (this.getInformation().Size != HEADER_SIZE + GTIN_SIZE + WEIGHT_SIZE)
         {
            return null;
         }

         StringBuilder buf = new StringBuilder();

         encodeCompressedGtin(buf, HEADER_SIZE);
         encodeCompressedWeight(buf, HEADER_SIZE + GTIN_SIZE, WEIGHT_SIZE);

         return buf.ToString();
      }
   }
}
