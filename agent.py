from langchain_ollama.llms import OllamaLLM
from langchain_core.prompts import ChatPromptTemplate
from vector import retriever

model = OllamaLLM(model="llama3.2")

template = """
You are an expert in answering questions about movies. You give short answer.

Here are some relevant movie descriptions: {descriptions}

Here is the question to answer: {question}
"""

prompt = ChatPromptTemplate.from_template(template)
chain = prompt | model

def respond_to_question( question ):
    descriptions = retriever.invoke(question)
    answer = chain.invoke({"descriptions": descriptions, "question": question})
    return answer