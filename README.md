# RaceDay Event Management System - Full Project

## Project Overview
This is the complete RaceDay Event Management System, built across three parts for PROG6212. 

- **Part 1:** System planning, ERD, API endpoint plan, and SQL database script.
- **Part 2:** RESTful API built with ASP.NET Core 9, Entity Framework Core, and SQL Server.
- **Part 3:** MVC Frontend consuming the API, with Azure Blob Storage integration and Docker setup.

## System Description
RaceDay is a full-stack web-based event management system designed for the South African road running, walking, and cycling community. 

## Roles
- **Participant:** Browse events, register, view entry history, and track performance.
- **Organiser:** Create and manage events, view enrolments, and capture results.

## Database Design (6 Entities)
- **User:** Authentication and login details.
- **Participant:** Personal details for race participants.
- **Organiser:** Event organisers and organisations.
- **Event:** Race/event details.
- **Entry:** Participant registrations.
- **Result:** Race results.

## Part 1: Database & Planning
- **ERD:** `docs/PROG6212 PART 1 2026.pdf`
- **API Plan:** `docs/PROG6212 PART 1 2026.pdf`
- **SQL Script:** `docs/raceday-schema.sql`

## Part 2: API Development
- **Tech Stack:** ASP.NET Core 9, EF Core 9, SQL Server, JWT, BCrypt, Swagger.
- **Key Features:** JWT Authentication, Role-based authorization (Organiser vs Participant).
- **Unit Tests:** 21 tests passing (xUnit + Moq + FluentAssertions).
- **CI/CD:** GitHub Actions automated build.

## Part 3: MVC Frontend & Docker
- **MVC Project:** `Part3/RaceDayMVC/`
- **API Connection:** MVC connects to the Part 2 API via `ApiService.cs`.
- **Authentication:** Register/Login using the API, session management.
- **Dashboards:** Role-based dashboards (Organiser and Participant).
- **Azure Blob Storage:** Image upload form implemented for Organiser events.
- /
├── README.md
├── docs/
│ ├── PROG6212 PART 1 2026.pdf
│ └── raceday-schema.sql
├── Part2/
│ └── RaceDayAPI/ (The API project)
└── Part3/
└── RaceDayMVC/ (The MVC Frontend)

## Docker Setup (Part 3)
To run the MVC app in Docker:
1. Navigate to `Part3/RaceDayMVC`.
2. Build the image: `docker build -t raceday-mvc .`
3. Run the container: `docker run -p 8080:80 raceday-mvc`

## Video Walkthrough
[Watch the Full Walkthrough Video](YOUR_YOUTUBE_LINK_HERE)https://youtu.be/v6IX8lylquU

## Author
**Innocentia Tlotleng**  
Course: PROG6212  
Date: November 2026

---
Copyright The Independent Institute of Education (Pty) Ltd 2026
- **Docker:** Multi-stage `Dockerfile` created to containerize the MVC application.

## Project Structure
