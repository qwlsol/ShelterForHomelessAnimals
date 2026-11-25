using System.Windows.Forms;
using System.Drawing;

namespace ShelterAdmin.Utils;

//отвечает за внешний вид таблицы
public static class GridConfigurator
{
    public static void Setup(DataGridView grid)
    {
        string[] hiddenColumns = {
            "Id", "Description", "HealthInfo", "Photos",
            "Species", "Gender", "Size", "Status",
            "MainPhoto", "StatusBadgeClass", "Age"
        };

        foreach (var colName in hiddenColumns)
        {
            if (grid.Columns[colName] != null)
            {
                grid.Columns[colName].Visible = false;
            }
        }

        if (grid.Columns["Name"] != null) grid.Columns["Name"].HeaderText = "Кличка";
        if (grid.Columns["SpeciesText"] != null) grid.Columns["SpeciesText"].HeaderText = "Вид";
        if (grid.Columns["Breed"] != null) grid.Columns["Breed"].HeaderText = "Порода";
        if (grid.Columns["GenderText"] != null) grid.Columns["GenderText"].HeaderText = "Пол";
        if (grid.Columns["AgeText"] != null) grid.Columns["AgeText"].HeaderText = "Возраст";
        if (grid.Columns["SizeText"] != null) grid.Columns["SizeText"].HeaderText = "Размер";
        if (grid.Columns["StatusText"] != null) grid.Columns["StatusText"].HeaderText = "Статус";

        if (grid.Columns["ArrivalDate"] != null)
        {
            grid.Columns["ArrivalDate"].HeaderText = "Дата поступления";
            grid.Columns["ArrivalDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }
    }
}