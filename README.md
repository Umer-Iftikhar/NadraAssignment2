# NADRA Citizen Registration System

Visual Programming – Assignment #2 (BSE-5A)

A C# Windows Forms (.NET 8) application that models a simplified NADRA citizen database, with an OpenCV image-effects module.

**Group members**
- Umer Iftikhar (09-131242-089)
- Qasim Abdul Qadeer Khan (09-131242-075)

## Features
- Admin login (3 attempts)
- Register, edit, update and delete citizens (CNIC, name, father name, gender, date of birth, province, marital status, phone, address, height, disability, photo)
- Validation: CNIC format and province code, gender digit, age 18+, duplicate CNIC check
- Automatic CNIC issue/expiry dates (lifetime for 60+)
- Search by name, father name or CNIC in a DataGridView
- OpenCV Image Lab: Grayscale, Blur, Sharpen, Edge Detection, Pencil Sketch, Cartoon, Sepia, Invert, plus brightness control

## Tech stack
- C# / .NET 8 Windows Forms
- SQLite (`Microsoft.Data.Sqlite`) with Dapper
- OpenCvSharp4

## Run
Open `NadraSystem.sln` in Visual Studio 2022 and press F5. The SQLite database (`nadra.db`) is created automatically with sample records on first run.

> [!NOTE]
> Login: `admin` / `admin123`
