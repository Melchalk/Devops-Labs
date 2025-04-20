from datetime import datetime
from sqlalchemy.orm import DeclarativeBase
from sqlalchemy import Column, Integer, String, create_engine, DateTime
from pydantic import BaseModel

DB_CONNECTION = "postgresql+psycopg2://postgres@postgres:5432/postgres"
engine = create_engine(DB_CONNECTION, echo=False)

class Base(DeclarativeBase): pass

class User(BaseModel):
    name: str
    age: int
    created_at: datetime

class DbUser(Base):
    __tablename__ = "users"
    id = Column(Integer, primary_key=True, autoincrement=True)
    name  = Column(String, unique=False)
    age = Column(Integer, unique=False)
    created_at = Column(DateTime(timezone=True))

Base.metadata.create_all(bind=engine)