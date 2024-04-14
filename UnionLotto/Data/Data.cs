﻿/*
 *Description: Data
 *Author: Chance.zheng
 *Creat Time: 2024/4/8 16:06:43
 *.Net Version: 6.0
 *CLR Version: 4.0.30319.42000
 *Copyright © CookCSharp 2024 All Rights Reserved.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionLotto
{
    public class Data
    {
        //记得每次更新历史数据文件


        /// <summary>
        /// 上期开奖号码
        /// </summary>
        public static int[] PreRedBlueLotto = new int[7] { 11, 14, 18, 19, 23, 26, 2 };

        /// <summary>
        /// 当前开奖期数
        /// </summary>
        public const int CurrentPeriod = 41; //仅仅打印信息所用

        /// <summary>
        /// 每期开奖必有红色号码
        /// <para>命中4、5、6个的概率很低，命中0、3个概率其次，命中1、2个概率较大</para>
        /// <para>命中概率排序，以1000组数据来看，1>2>3=0>4>5>6，命中概率分别为：36%、34%、各为13.5%、和为3%</para>
        /// </summary>
        public static int[] EveryHaveNums = new int[9] { 4, 5, 13, 14, 20, 21, 27, 28, 29 };

        /// <summary>
        /// 所有质数
        /// <para>命中5、6个的概率几乎为0，命中0、4个的概率很低，命中13个的概率其次，命中2个概率较大</para>
        /// <para>命中概率排序，以1000组数据来看，2>3=1>4>0>5=6，命中概率分别为：37%、26%、23%、9%、4%、和为1%</para>
        /// </summary>
        public static int[] AllPrimeNums = new int[12] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

        /// <summary>
        /// 所有红色号码
        /// </summary>
        public static int[] AllRedLotto = new int[33] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33 };

        /// <summary>
        /// 所有蓝色号码
        /// </summary>
        public static int[] AllBlueLotto = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        /// <summary>
        /// 红色号码最小和值
        /// </summary>
        public const int MinRedSum = 21;

        /// <summary>
        /// 红色号码最大和值
        /// </summary>
        public const int MaxRedSum = 183;

        public static void SetRedBlueLotto(IEnumerable<int> lotto) => PreRedBlueLotto = lotto.ToArray();

        static void InitData()
        {
            //通过观察可知
            //命中个数>=4个
            //重复号码中有0-2个号码可能出现


            //2 4 5 8 9 10 13 15 17 18 19 21 23 26 28 31 33
            //命中个数：4  缺失个数：2
            var data40 = new int[7] { 11, 14, 18, 19, 23, 26, 2 };

            //2 4 5 8 9 10 13 15 17 18 19 21 23 26 28 31 33
            //命中个数：2  缺失个数：4
            var data39 = new int[7] { 2, 6, 12, 29, 30, 31, 10 };

            //1,2,3,4,5,6,7,8,9,10,11,13,15,16,17,18,19,20,26
            //1,1,2,2,3,4,5,5,6,6,7,7,8,8,9,9,10,10,11,11,13,13,15,16,17,18,18,19,20,26
            //命中个数：3  缺失个数：3
            var data38 = new int[7] { 8, 10, 18, 23, 27, 31, 2 };

            //1,3,4,6,7,9,10,11,12,13,14,17,19,20,21,22,23,29,30,33
            //1,3,4,6,7,9,10,10,10,11,12,13,14,17,19,19,20,21,22,23,23,29,29,30,33,33
            //命中个数：5  缺失个数：1  
            var data37 = new int[7] { 1, 4, 5, 6, 12, 14, 13 };

            //2,3,5,7,8,9,10,12,15,17,18,19,21,22,24,25,27,29,31
            //2,3,5,7,8,9,10,10,12,12,15,15,17,18,19,21,22,24,25,27,27,29,31
            //命中个数：6  缺失个数：0  
            var data36 = new int[7] { 2, 8, 9, 12, 21, 31, 2 };

            //2,3,7,9,10,11,12,14,17,19,21,22,23,28,29,30,31,33
            //2,3,7,7,9,10,10,10,11,12,12,14,17,19,19,21,21,22,23,28,29,30,31,33,33
            //命中个数：4  缺失个数：2
            var data35 = new int[7] { 5, 7, 14, 17, 22, 32, 6 };

            //1,2,4,5,7,8,9,10,12,14,16,17,21,22,24,26,28,29,30,31
            //1,2,4,5,7,8,9,10,12,12,14,14,16,17,21,21,22,24,26,26,28,29,30,31
            //命中个数：5  缺失个数：1 
            var data34 = new int[7] { 2, 9, 12, 19, 21, 31, 4 };

            //1,2,3,4,5,7,8,9,10,11,12,13,14,15,16,17,18,20,22,23,24,25,32,33
            //1,1,2,3,4,5,7,7,8,8,9,9,10,10,11,12,13,14,15,15,16,17,18,20,22,23,24,25,32,33
            //命中个数：5  缺失个数：1 
            var data33 = new int[6] { 6, 10, 11, 18, 20, 32 };

            //1,2,3,4,5,7,12,15,16,17,19,20,21,22,23
            //1,2,3,4,5,7,12,15,16,17,19,19,20,21,22,22,23,23
            //命中个数：5  缺失个数：1  
            var data32 = new int[6] { 1, 3, 4, 11, 12, 21 };

            //3,4,4,7,7,8,9,11,14,17,21,21,23,24,25,26,28,30,30,32,33
            //命中个数：4  缺失个数：2  
            var data31 = new int[6] { 9, 10, 13, 25, 30, 32 };

            //2,3,5,5,5,6,7,8,10,10,11,13,15,16,21,30
            //命中个数：1  缺失个数：5
            var data30 = new int[6] { 1, 8, 22, 25, 29, 33 };

            //1,1,3,4,4,5,7,8,8,10,10,11,11,11,12,14,15,15,16,18,19,21,22,25,26,26,27,29,30
            //命中个数：3  缺失个数：3
            var data29 = new int[6] { 12, 18, 23, 25, 28, 33 };

            var data28 = new int[6] { 3, 7, 8, 11, 18, 19 };
        }
    }
}
