# 🧠 AI-Powered Movie Recommendation Agent

This repository contains a prototype application that provides intelligent movie recommendations using a local AI agent. The project integrates a C# Windows Forms frontend with a Python Flask backend.

## ✨ Features

* **Natural Language Queries**: Users can enter questions or prompts through a Windows Forms UI.
* **AI Integration**: The backend forwards the question to a locally hosted language model via **Ollama** to generate movie recommendations.
* **API Communication**: Uses HTTP POST requests to communicate between the C# frontend and the Python API.
* **Persistent Storage**: All user queries and AI-generated responses are stored in a local database using **SQLAlchemy**.
* **Storage Limit**: The application enforces a fixed limit on the number of stored entries (hardcoded in this version).
* **Extensible Architecture**: Easily extendable to include features such as authentication, dynamic limits, and analytics.

## 🛠️ Tech Stack

* **Frontend**: C# (.NET Windows Forms)
* **Backend**: Python with Flask
* **Database**: SQLite managed with SQLAlchemy
* **AI Engine**: Local LLM powered by **Ollama**

## 🚀 Getting Started

### Prerequisites

* Python 3.8+
* Visual Studio with .NET Desktop Development workload
* Ollama installed and running locally

### Backend Setup

1. Navigate to the `backend/` directory:

   ```bash
   cd backend
   ```
2. Create a virtual environment:

   ```bash
   python -m venv venv
   source venv/bin/activate  # On Windows: venv\Scripts\activate
   ```
3. Install dependencies:

   ```bash
   pip install -r requirements.txt
   ```
4. Run the Flask app:

   ```bash
   flask run
   ```
<!--
### Frontend Setup

1. Open the `MovieRecommenderApp.sln` solution in Visual Studio.
2. Build and run the application.
3. Enter your query and click submit to receive a movie recommendation.
-->
## 🔐 Future Enhancements

* Add API key support for request authentication
* Configurable storage limits via `.env` or admin settings
* Enhanced error handling and logging
<!--
* Dockerized deployment for full-stack portability

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

Feel free to contribute by opening issues or submitting pull requests!
-->
