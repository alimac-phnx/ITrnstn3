using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ITrnstn3
{
    public class HelpTable
    {
        private Table table;

        public HelpTable(string[] columnNames)
        {
            table = new Table();

            var firstColumn = new TableColumn("v PC\\User >").Centered();
            table.AddColumn(firstColumn);

            foreach (var cN in columnNames)
            {
                table.AddColumn(new TableColumn(cN).Centered().Width(10));
            }

            foreach (var rows in BuildRows(columnNames))
            {
                var coloredRows = ColorTable(rows);
                
                table.AddRow(coloredRows.ToArray());
            }
        }

        public void Print()
        {
            Console.WriteLine("The result is described from the user's point of view\n");

            table.Border(TableBorder.Rounded);
            table.Expand = true;

            table.ShowFooters = false;
            table.ShowHeaders = true;

            AnsiConsole.Write(table);
        }

        public List<List<string>> BuildRows(string[] args)
        {
            List<List<string>> tableRows = new List<List<string>>();
            for (int i = 0; i < args.Length; i++)
            {
                tableRows.Add(new List<string>());

                tableRows[i].Add(args[i]);
            }

            FightClub fightClub = new FightClub(); ;

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length; j++)
                {
                    fightClub.UserMove = i;
                    fightClub.CompMove = j;
                    fightClub.Moves = args;

                    tableRows[i].Add(fightClub.FightInfo());
                }
            }

            return tableRows;
        }

        public List<string> ColorTable(List<string> rows)
        {
            var coloredRows = new List<string>();

            foreach (var cell in rows)
            {
                if (cell.ToLower() == "win")
                {
                    coloredRows.Add($"[green]{cell}[/]");
                }
                else if (cell.ToLower() == "lose")
                {
                    coloredRows.Add($"[yellow]{cell}[/]");
                }
                else
                {
                    coloredRows.Add(cell);
                }
            }

            return coloredRows;
        }
    }
}