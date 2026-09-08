# Hope World — Product Rules

## Users

Roles:
- Student
- Instructor
- Manager / Head

Students:
- Have a lightweight profile.
- Have a name and avatar.
- Do not use passwords.
- Do not use traditional authentication.

## Classes

- Every student belongs to a class.
- Every class has an instructor.
- One instructor may teach multiple classes.

## Learning

Academic subjects initially:
- Arabic
- English

Each subject:
- Contains multiple levels.
- Each level has a learning model.
- Each level contains quizzes.

Quiz types:
- Choose
- Matching
- Drag & Drop
- Typing

## Progress

Class:
- Has one active level per subject.

Student:
- Has independent progress per subject.
- Can resume from the last saved position.

## Scoring

Initial scoring is based on correct answers.

Students may retake quizzes.

Avoid introducing advanced scoring logic without an explicit requirement.

## Content

Educational content is dynamic.

The frontend renders structured content.

Do not hard-code curriculum content into UI components.