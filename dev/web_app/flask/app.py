from flask import Flask, render_template

app = Flask(__name__)

@app.route("/")
def home():
    return render_template('index.html')

@app.route("/user/sign_up")
def sign_up():
    return render_template('user/sign_up.html')

@app.route("/user/login")
def login():
    return render_template('user/login.html')

if __name__ == '__main__':
    app.run(debug=True, port=8080)