from flask import Flask, request
from dotenv import load_dotenv
import os
import psycopg2

load_dotenv()
app = Flask(__name__)
conn = psycopg2.connect(
    database=os.getenv('POSTGRES_DATABASE'),
    user=os.getenv('POSTGRES_USER'),
    password=os.getenv('POSTGRES_PASSWORD'),
    host=os.getenv('POSTGRES_HOST')
)

@app.route("/")
def home():
    cursor = conn.cursor()
    cursor.execute("INSERT INTO users (name, email, password) VALUES (%s, %s, %s)", ('TallGuy', 'sthomas@mac.com', '1234'))
    conn.commit()
    cursor.close()
    return

@app.route("/user/sign_up", methods=['POST'])
def sign_up():
    if request.method == 'POST':
        email = request.form['email']
        username = request.form['username']
        password = request.form['password']
        cursor = conn.cursor()
        cursor.execute("INSERT INTO users (name, email, password) VALUES (%s, %s, %s)", (username, email, password))
        conn.commit()
        cursor.close()
        
    return

@app.route("/user/login")
def login():
    return render_template('user/login.html')

if __name__ == '__main__':
    app.run(debug=True, port=8080)