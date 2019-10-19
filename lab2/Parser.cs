using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab2
{
    enum state{
        END,
        ERROR
    }

    static class Parser
    {
        const char SPACE = ' ';
        const string SHOW_MATRIX = "^\\D+\\w?$";
        const string CREATE_MATRIX = "(^\\D+\\w?){1}\\s?=(\\s?[\\d]{1,}\\s?[,]?)+\\d?$";
        const string OPERATION_MATRIX = "(^\\w+\\d?){1}\\s[=]\\s(\\w+\\d?){1}\\s[\\-,+,*]\\s(\\w+\\d?){1}$";
        private static char[] operations = {'-', '+', '*'};

        public static bool tryParse(string s)
        {
            // возможно в строке только имя переменной
            // тогда отобразить ее значение
            if (Regex.IsMatch(s, SHOW_MATRIX))
                Action.showMatrix(s);
            else if (Regex.IsMatch(s, CREATE_MATRIX))
                tryParseMatrixLine(s);
            else if (Regex.IsMatch(s, OPERATION_MATRIX))
                tryParseMatrixLineOperation(s);
            else
                return false;
            return true;
        }

        public static void tryParseMatrixLine(string matrixLine)
        {
            string[] splitted = matrixLine.Split('=');
            // слева от = имя матрицы
            string matrixName = splitted[0];
            matrixName = matrixName.Trim(SPACE);
            // справа от = элементы матрицы
            string matrixElements = splitted[1];
            matrixElements = matrixElements.Trim(SPACE);
            // создать матрицу по строке
            Action.createMatrix(matrixName, matrixElements);
        }

        public static void tryParseMatrixLineOperation(string matrixLine)
        {
            string[] splitted = matrixLine.Trim(SPACE).Split('=');
            // слева от =, матрица-приемник
            string recipient = splitted[0].Trim(SPACE);
            // справа от =, операнд 1, символ операции и операнд 2
            string rightSide = splitted[1].Trim(SPACE);

            splitted = rightSide.Trim(SPACE).Split('-', '+', '*');
            // операнд 1
            string op1 = splitted[0].Trim(SPACE);
            // операнд 2
            string op2 = splitted[1].Trim(SPACE);
            // индекс символа операции
            char operation = rightSide[rightSide.IndexOfAny(operations)];
            // выполнить операцию operation над операндами op1 и op2
            Action.operationMatrix(recipient, op1, operation, op2);
        }
    }

    // для реализации синтаксического анализа посредством конечных автоматов
    static class Automaton
    {
        private static state state;   

        public static bool isWork {
            get { return (state != state.END && state != state.ERROR) ? true : false; }                
        }

        public static void run(string s)
        {
            switch (s)
            {
                default: break;
            }
        }
    }

}
