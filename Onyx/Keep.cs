﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    class Keep
    {
        public static int[,] exteriorBackground =
        {
            { -1, -1, -1,  0, -1, -1, -1, -1, -1, -1,  0, -1,  0,  0 },
            { -1, -1,  0,  0, -1, -1,  0,  0, -1, -1,  0,  0,  0,  0 },
            { -1,  0,  0, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
            {  0,  0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
            {  0,  0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
            {  0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
            { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0,  0 },
        };

        public static int[,] exteriorForeground =
        {
            { -1, -1, -1, -1,  8,  8, -1, -1,  8,  8, -1, -1,  8,  8 },
            { -1, -1, -1, -1,  8,  8, -1, -1,  8,  8, -1, -1,  8,  8 },
            { -1, -1, -1,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8 },
            { -1, -1,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8 },
            { -1, -1,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8 },
            { -1,  8,  8,  8,  8,  0,  0,  0,  0,  8,  8,  8,  8, -1 },
            {  8,  8,  8,  8,  8,  0,  0,  0,  0,  8,  8,  8, -1, -1 },
            {  8,  8,  8,  8,  0,  0,  0,  0,  0,  0,  8,  8,  8, -1 },
            {  8,  8,  8,  8,  0,  0,  0,  0,  0,  0,  8,  8,  8, -1 },
            {  8,  8,  8,  8,  0,  0,  0,  0,  0,  0,  8,  8,  8,  8 },
            {  8,  8,  8,  8,  0,  0,  0,  0,  0,  0,  8,  8,  8,  8 },
            {  8,  8,  8,  8,  0,  0,  0,  0,  0,  0,  8,  8,  8,  8 },
        };
    }
}
