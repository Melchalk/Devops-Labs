FROM python:3.12-slim
WORKDIR /app
COPY main.py .
CMD ["python", "main.py"]

FROM python:3.12-slim as build
WORKDIR /install
COPY requirements.txt .
RUN pip install --no-cache-dir --prefix=/install/deps -r requirements.txt

FROM python:3.12-alpine
WORKDIR /app
COPY --from=build /install/deps /usr/local
COPY main.py .

CMD ["python", "main.py"]
