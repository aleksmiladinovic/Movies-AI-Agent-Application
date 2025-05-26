from flask import Flask
from flask_restful import Api, Resource, reqparse
from flask_sqlalchemy import SQLAlchemy
from agent import respond_to_question
import os

app = Flask(__name__)
api = Api(app)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///history.db'
db = SQLAlchemy(app)

history_limit = 3
history_counter = 0

class QuestionModel(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    question = db.Column(db.String(100), nullable=False)
    answer = db.Column(db.String(100), nullable=False)

    def form_conv(self):
        return f" =========\n Q: {question} \n =========\n A: {answer} \n\n" 

data = reqparse.RequestParser()
data.add_argument("question", type=str, help="Valid question error")

class QAnswer(Resource):
    def post(self):
         global history_counter
         global history_limit
         history_counter += 1
         if history_counter > history_limit:
             history_counter = history_limit + 1
             return 'History is full', 507  
         args = data.parse_args()
         question = args["question"]
         answer = respond_to_question( question=question )
         querry = QuestionModel(id=history_counter, question=question, answer=answer)
         db.session.add(querry)
         db.session.commit()
         return answer
    
class History(Resource):
    def get(self):
        all_history = QuestionModel.query.all()
        result = ''
        for entry in all_history:
            result += f" =========\n Q: {entry.question} \n =========\n A: {entry.answer} \n\n"
        return result
    
    def delete(self):
        global history_counter
        history_counter = 0
        db.drop_all()
        db.create_all()
    
api.add_resource(QAnswer,"/ask")
api.add_resource(History,"/history")

if __name__ == "__main__":
    if not os.path.exists('history.db'):
        with app.app_context():
            db.create_all()

    app.run(debug=False)
