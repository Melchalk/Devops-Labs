from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from sqlalchemy.orm import sessionmaker
from models import engine, User

import users_funcs

SessionLocal = sessionmaker(autoflush=False, bind=engine)
db = SessionLocal()

app = FastAPI()
app.add_middleware(
    CORSMiddleware,
    allow_origins=['*'],
    allow_credentials=True,
    allow_methods=['*'],
    allow_headers=['*']
)

@app.post("/add/person")
def add_user(user: User):
    return users_funcs.add_user(user, db)