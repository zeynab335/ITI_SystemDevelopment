use FacultySystemV2;

// start create student collection
db.createCollection("student");

// start create schema of student collection
db.runCommand({
    collMod:"student",
    validator:{
        $jsonSchema:{
            bsonType:"object",
            properties: {
                 _id: {
                    bsonType: "number"
                },
                firstName:{
                    bsonType:"string"
                }, 
                lastName:{
                    bsonType:"string"
                },
                isFired:{
                    bsonType:"bool"
                },
                facultyID:{
                    bsonType:"number"
                },
                Courses:{
                    bsonType:["array"],
                    items:{
                         bsonType: "object",
                        required: ["courseID", "grade"],
                        properties: {
                            courseID: {
                                bsonType: "number"
                            },
                            grade: {
                                bsonType: "number"
                            }
                        }
                    }
                 
                } // end courses defination
                
            }
        }
    } // end Validator
})

// ************************************************************************************
// start creation of Faculty collection
db.createCollection("Faculty");
db.runCommand({
    collMod : "Faculty",
    validator:{
        $jsonSchema:{
            bsonType:"object",
            properties: {
                 _id: {
                    bsonType: "number"
                },
                "facultyName":{
                    bsonType:"string"
                }, 
                Address:{
                    bsonType:"string"
                }
            } // end properties
        } // end json schema
    } // end Validator
})// end runcommand of Faculty

// ************************************************************************************
// start Course of Course collection

db.createCollection("Course");
db.runCommand({
    collMod : "Course",
    validator:{
        $jsonSchema:{
            bsonType:"object",
            properties: {
                 _id: {
                    bsonType: "number"
                },
                "courseName":{
                    bsonType:"string"
                }, 
                "finalMark":{
                    bsonType:"number"
                }
            } // end properties
        } // end json schema
    } // end Validator
})// end runcommand of Course


// insert data into collections

db.student.insertMany(

    [{
        _id: 2, firstName: "sara", lastName: "mohamed", isFired: false,
        facultyID: 1, Courses: [{ courseID: 1, grade: 10 }, { courseID: 2, grade: 6 }, { courseID: 3, grade: 8 }]
    },
    {
        _id: 3, firstName: "hala", lastName: "ahmed", isFired: false,
        facultyID: 1, Courses: [{ courseID: 1, grade: 10 }, { courseID: 2, grade: 5 }, { courseID: 3, grade: 8 }]
    },
    {
        _id: 4, firstName: "khaled", lastName: "zaki", isFired: true,
        facultyID: 1, Courses: [{ courseID: 1, grade: 4 }, { courseID: 2, grade: 9 }, { courseID: 3, grade: 6 }]
    },
    {
        _id: 5, firstName: "ahmed", lastName: "adel", isFired: false,
        facultyID: 1, Courses: [{ courseID: 1, grade: 2 }, { courseID: 2, grade: 8 }, { courseID: 3, grade: 9 }]
    },
    {
        _id: 6, firstName: "salah", lastName: "ali", isFired: true,
        facultyID: 1, Courses: [{ courseID: 1, grade: 10 }, { courseID: 2, grade: 9 }, { courseID: 3, grade: 8 }]
    },
    {
        _id: 7, firstName: "hazem", lastName: "nazmy", isFired: false,
        facultyID: 1, Courses: [{ courseID: 1, grade: 10 }, { courseID: 2, grade: 1 }, { courseID: 3, grade: 5 }]
    }]

)

// insert data into Faculty

db.Course.insertMany(

    [{ _id: 1, courseName: "course1", finalMark: 10 },
    { _id: 2, courseName: "course1", finalMark: 10 },
    { _id: 3, courseName: "course1", finalMark: 10 }
    ]

)
db.Course.insertMany(

    [{ _id: 4, courseName: "course2", finalMark: 10 },
    { _id: 5, courseName: "course2", finalMark: 10 },
    ]
)
db.Faculty.insertOne(

    { _id: 1, "facultyName": "acb", address: "123 xyz st" }

)
//************************************************************************
//2 2. Display each student Full Name along with his average grade in all courses. $concat
db.student.aggregate(
    [
        {$project:{
            fullName : {$concat:["$firstName" , " " , "$lastName"]},
            grade: {$avg : "$Courses.grade" }
        }}
    ]
    
)

db.student.find({})


//*********************************************************************************
//3. Using aggregation display the sum of final mark for all courses in Course collection.
db.Course.aggregate(
    [
        { $group: { _id: "$courseName", finalMarks: { $sum: "$finalMark" } } },
        { $project: { _id: 1, finalMarks: 1 } }
    ]   
)

db.Course.find({})


//*********************************************************************************
// 4. Implement (one to many) relation between Student and Course,
db.student.aggregate(
    [
        {$match:{ firstName : "ahmed"}},
        {$lookup:{
            from :"Course",
            localField:"Courses.courseID",
            foreignField:"_id",
            as: "StudentCourses"
           
        }},
            {
                $project: { _id: 0, isFired: 0, Courses: 0 }
            }
    ]
)


db.Faculty.find()
db.student.aggregate(
    [
        {
            $match: { firstName: "ahmed" }
        },
        {
            $lookup: {
                from: "Faculty",
                localField: "facultyID", 
                foreignField: "_id",
                as: "StudentFaculty" 
            }
        },
        {
            $project: { _id: 0, isFired: 0, Courses: 0, facultyID: 0 }
        }
    ]
)


db.student.createIndex({ lastName: 1 }, { name: "lastNameIndex", background: true }) 

db.student.find({ lastName: "ahmed" }).explain()



