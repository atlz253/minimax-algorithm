namespace PZIS_4
{
    /// <summary>
    /// Отвечает за создание деревьев по заданному варианту
    /// </summary>
    internal static class TreeFactory
    {
        /// <summary>
        /// Создает 2 вариант дерева
        /// </summary>
        /// <returns>Корень дерева</returns>
        public static Node BuildTree_2()
        {
            Node root = new();

            // Формат имени l<уровень>_<индекс узла на этом уровне>
            Node l1_0 = new();
            Node l1_1 = new();
            Node l1_2 = new();

            root.Add(l1_0);
            root.Add(l1_1);
            root.Add(l1_2);

            Node l2_0 = new();
            Node l2_1 = new();
            Node l2_2 = new();
            Node l2_3 = new();
            Node l2_4 = new();
            Node l2_5 = new();

            l1_0.Add(l2_0);
            l1_0.Add(l2_1);

            l1_1.Add(l2_2);
            l1_1.Add(l2_3);

            l1_2.Add(l2_4);
            l1_2.Add(l2_5);

            Node l3_0 = new();
            Node l3_1 = new();
            Node l3_2 = new();
            Node l3_3 = new();
            Node l3_4 = new();
            Node l3_5 = new();
            Node l3_6 = new();
            Node l3_7 = new();
            Node l3_8 = new();
            Node l3_9 = new();
            Node l3_10 = new();
            Node l3_11 = new();
            Node l3_12 = new();
            Node l3_13 = new();
            Node l3_14 = new();

            l2_0.Add(l3_0);
            l2_0.Add(l3_1);
            l2_0.Add(l3_2);

            l2_1.Add(l3_3);
            l2_1.Add(l3_4);
            l2_1.Add(l3_5);

            l2_2.Add(l3_6);
            l2_2.Add(l3_7);

            l2_3.Add(l3_8);
            l2_3.Add(l3_9);
            l2_3.Add(l3_10);

            l2_4.Add(l3_11);
            l2_4.Add(l3_12);

            l2_5.Add(l3_13);
            l2_5.Add(l3_14);

            Node l4_0 = new(4);
            Node l4_1 = new(3);
            Node l4_2 = new(6);
            Node l4_3 = new(5);
            Node l4_4 = new(2);
            Node l4_5 = new(7);
            Node l4_6 = new(8);
            Node l4_7 = new(3);
            Node l4_8 = new(2);
            Node l4_9 = new(7);
            Node l4_10 = new(6);
            Node l4_11 = new(6);
            Node l4_12 = new(9);
            Node l4_13 = new(8);
            Node l4_14 = new(8);
            Node l4_15 = new(4);
            Node l4_16 = new(3);
            Node l4_17 = new(1);
            Node l4_18 = new(6);
            Node l4_19 = new(5);
            Node l4_20 = new(4);
            Node l4_21 = new(4);
            Node l4_22 = new(3);
            Node l4_23 = new(5);
            Node l4_24 = new(6);
            Node l4_25 = new(7);
            Node l4_26 = new(7);
            Node l4_27 = new(7);
            Node l4_28 = new(4);
            Node l4_29 = new(3);
            Node l4_30 = new(2);
            Node l4_31 = new(6);
            Node l4_32 = new(7);
            Node l4_33 = new(9);
            Node l4_34 = new(8);
            Node l4_35 = new(9);

            l3_0.Add(l4_0);
            l3_0.Add(l4_1);

            l3_1.Add(l4_2);
            l3_1.Add(l4_3);

            l3_2.Add(l4_4);
            l3_2.Add(l4_5);
            l3_2.Add(l4_6);

            l3_3.Add(l4_7);
            l3_3.Add(l4_8);

            l3_4.Add(l4_9);
            l3_4.Add(l4_10);
            l3_4.Add(l4_11);

            l3_5.Add(l4_12);
            l3_5.Add(l4_13);
            l3_5.Add(l4_14);

            l3_6.Add(l4_15);
            l3_6.Add(l4_16);

            l3_7.Add(l4_17);
            l3_7.Add(l4_18);

            l3_8.Add(l4_19);
            l3_8.Add(l4_20);

            l3_9.Add(l4_21);
            l3_9.Add(l4_22);
            l3_9.Add(l4_23);

            l3_10.Add(l4_24);
            l3_10.Add(l4_25);

            l3_11.Add(l4_26);
            l3_11.Add(l4_27);

            l3_12.Add(l4_28);
            l3_12.Add(l4_29);
            l3_12.Add(l4_30);

            l3_13.Add(l4_31);
            l3_13.Add(l4_32);

            l3_14.Add(l4_33);
            l3_14.Add(l4_34);
            l3_14.Add(l4_35);

            return root;
        }
    }
}
