﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHarvestPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "PaymentDate",
                table: "HarvestPayment",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "HarvestPayment");
        }
    }
}
