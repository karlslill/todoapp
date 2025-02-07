# **ToDo App**

## **Technologies Used & Reasoning**
This application is built using:
- **Backend:** `.NET 8 (C#)`
- **Frontend:** `Vue 3`
- **Database:** `SQLite`

### **Why these technologies?**
- **.NET 8**: A modern, high-performance backend framework that I am most familiar with. Seems more logical to me than Java.
- **Vue 3**: A lightweight and reactive frontend framework that allows for a smooth user experience and component-based development.
- **SQLite**: A simple and file-based database, which is good for lightweight applications without requiring a separate database server.

---

## **How to Run the Application Locally**

### **1. Backend (API - .NET 8)**
**Prerequisites:**
- Install **.NET 8 SDK** from [Microsoft](https://dotnet.microsoft.com/download/dotnet/8.0)
- Ensure you have `SQLite` installed or let .NET handle it automatically

**Steps to start the backend:**
```sh
# Navigate to the backend folder
cd ToDoApp/WebApp

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the API
dotnet run
```
The backend will start on **http://localhost:5138**

---

### **2. Frontend (Vue 3)**
**Prerequisites:**
- Install **Node.js** (v18+ recommended) from [Node.js official site](https://nodejs.org/)
- Install **Vue CLI** globally (if not installed)
  ```sh
  npm install -g @vue/cli
  ```

**Steps to start the frontend:**
```sh
# Navigate to the frontend folder
cd ToDoAppFront/todo-app-front

# Install dependencies
npm install

# Start the Vue development server
npm run dev
```
The frontend will be available at **http://localhost:5173**

---

## **Usage Notes**
- Ensure the backend is running before starting the frontend.
- The Vue app will automatically call the API at `http://localhost:5138`.
- If you face **CORS issues**, update the backend to allow requests from `http://localhost:5173`.  

## Docker Deployment

A `docker-compose.yml` file was created to run both frontend and backend in containers. However, **the Docker Compose setup was not finished due to memory limitations on personal computer**.