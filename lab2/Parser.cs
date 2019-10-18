using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab2
{
    static class Parser
    {
        const string SHOW_MATRIX = "^\\D+\\w?$";
        const string CREATE_MATRIX = "(^\\D+\\w?){1}\\s?=(\\s?[\\d]{1,}\\s?[,]?)+$";

        public static bool tryParse(string s)
        {
            // возможно в строке только имя переменной
            // тогда отобразить ее значение
            if (Regex.IsMatch(s, SHOW_MATRIX))
                Action.showMatrix(s);
            else if (Regex.IsMatch(s, CREATE_MATRIX))
                tryParseMatrixLine(s);
            else
                return false;
            return true;
            
        }

        public static void tryParseMatrixLine(string matrixLine)
        {
            string[] splitted = matrixLine.Split('=');
            // слева от = имя матрицы
            string matrixName = splitted[0];
            // справа от = элементы матрицы
            string matrixElements = splitted[1];
            matrixElements = matrixElements.Trim(' ');
            // создать матрицу по строке
            Action.createMatrix(matrixName, matrixElements);
        }
    }

    // для реализации синтаксического анализа посредством конечных автоматов
    abstract class automaton
    {
        abstract public void run();
    }

    class a1 : automaton
    {
        public override void run() { }
    }

}
