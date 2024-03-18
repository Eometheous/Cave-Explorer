from flask import Flask, render_template
from cassandra.cluster import Cluster

app = Flask(__name__)
cluster = Cluster(['0.0.0.0'], port=9042)
session = cluster.connect(keyspace="cave_explorer")

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