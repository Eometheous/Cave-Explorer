import asyncpg
import psycopg2
from bcrypt import checkpw
import bcrypt
from flask import Flask, jsonify, request
from dotenv import load_dotenv
import os

app = Flask(__name__)
def connect_to_database():
    load_dotenv()
    return psycopg2.connect(
        database=os.getenv('POSTGRES_DATABASE'),
        user=os.getenv('POSTGRES_USER'),
        password=os.getenv('POSTGRES_PASSWORD'),
        host=os.getenv('POSTGRES_HOST')
    )

def fetch_user(email):
    connection = connect_to_database()
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM users WHERE email='{0}'".format(email))
    user = user = cursor.fetchone()
    cursor.close()
    connection.close()
    return user

@app.route("/")
def home():
    return jsonify({'success': True})

@app.route("/user/sign-up", methods=['POST'])
def sign_up():
    connection = connect_to_database()
    if request.method == 'POST':
        email = request.form['email']
        username = request.form['username']
        password = request.form['password']
        cursor = connection.cursor()
        bytes = password.encode('utf-8') 
        salt = bcrypt.gensalt() 
        hash = bcrypt.hashpw(bytes, salt) 
        cursor.execute("INSERT INTO users (name, email, password) VALUES (%s, %s, %s)", (username, email, hash))
        connection.commit()
        cursor.close()
    return jsonify({
            'success': True,
            'message': 'Succesful'
        }), 200

@app.route("/user/login", methods=['POST'])
def login():
    data = request.form
    
    email = data.get('email')
    password = data.get('password')

    try:
        if not email or not password:
            raise ValueError('Email and password are required')
        
        user = fetch_user(email)

        if not user:
            raise ValueError('Email or password is incorrect')
        
        password_match = checkpw(password.encode('utf-8'), user[3].encode('utf-8'))

        if not password_match:
            raise ValueError('Email or password is inccorect')
        
        return jsonify({
            'success': True,
            'message': 'Login succesful',
            'user': {
                'email': user[2],
                'level': user[4]
            }
        }), 200
    
    except Exception as e:
        return jsonify({
            'success': False,
            'message': str(e)
        }), 500
    
def increment_user_level(email):
    connection = connect_to_database()
    cursor = connection.cursor()
    cursor.execute("UPDATE users SET level = level + 1 WHERE email='{0}'".format(email))
    connection.commit()
    cursor.close()
    connection.close()
    
@app.route("/user/increment-level", methods=['POST'])
def increment_level():
    data = request.form
    
    email = data.get('email')

    try:
        if not email:
            raise ValueError('Email required')
        
        user = fetch_user(email)

        if not user:
            raise ValueError('Email not found')
        
        increment_user_level(email)
        
        return jsonify({
            'success': True,
            'message': 'Increment succesful'
        }), 200
    
    except Exception as e:
        return jsonify({
            'success': False,
            'message': str(e)
        }), 500



if __name__ == '__main__':
    app.run(debug=True, port=8080)