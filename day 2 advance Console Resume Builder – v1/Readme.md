# 📝 Console Resume Builder – v1

A beginner-friendly C# console application that lets users build a mini resume by entering their basic details, then saves it to a `.txt` file.

---

## 📌 Features

- Collects user input for:
  - Full Name
  - Age
  - Email
  - City
- Validates:
  - Age (must be number)
  - Email (must include `@` and `.`)
  - Name and City (no numeric input)
- Saves each resume to a text file (`resume.txt`)
- Allows adding multiple users in a single run
- Clean console formatting with `Console.Clear()` and structure

---

## 💻 Technologies Used

- C# (.NET 6/7)
- Console Application
- File Handling (`System.IO`)
- Input Validation
- Optional Exit Strategy (`exit` keyword)

---

## 📂 How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/YOUR-USERNAME/resume-builder.git
