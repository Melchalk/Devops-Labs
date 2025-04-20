from datetime import datetime, timezone

from sqlalchemy.orm import Session
from models import DbUser, User

def add_user(user:User, db:Session):
    db.add(DbUser(name=user.name, age=user.age, created_at=datetime.now(timezone.utc)))
    db.commit()