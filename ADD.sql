-- Insert 10 Patients and store their IDs
WITH inserted_patients AS (
    INSERT INTO "Patients" ("FirstName", "LastName", "PatientNumber", "OIB", "DateOfBirth", "Gender")
    VALUES 
        ('John', 'Doe', 'P001', '12345678901', TIMESTAMP '1985-06-15 00:00:00', 'Male'),
        ('Jane', 'Smith', 'P002', '98765432101', TIMESTAMP '1990-08-22 00:00:00', 'Female'),
        ('Michael', 'Johnson', 'P003', '45678912345', TIMESTAMP '1978-04-10 00:00:00', 'Male'),
        ('Emily', 'Davis', 'P004', '78912345678', TIMESTAMP '1982-12-05 00:00:00', 'Female'),
        ('Daniel', 'Brown', 'P005', '32165498765', TIMESTAMP '1995-03-25 00:00:00', 'Male'),
        ('Olivia', 'Miller', 'P006', '65432178912', TIMESTAMP '1989-11-30 00:00:00', 'Female'),
        ('William', 'Wilson', 'P007', '15975346821', TIMESTAMP '1973-07-18 00:00:00', 'Male'),
        ('Sophia', 'Moore', 'P008', '75395145623', TIMESTAMP '1997-09-05 00:00:00', 'Female'),
        ('James', 'Taylor', 'P009', '85245612398', TIMESTAMP '1980-02-14 00:00:00', 'Male'),
        ('Isabella', 'Anderson', 'P010', '95135724682', TIMESTAMP '1992-01-28 00:00:00', 'Female')
    RETURNING "Id"
)
SELECT * FROM inserted_patients;

-- Insert Medical History for each Patient
INSERT INTO "MedicalHistories" ("PatientId", "DiseaseName", "StartDate", "EndDate")
SELECT 
    "Id", 
    unnest(ARRAY[
        'Hypertension', 'Diabetes', 'Asthma', 'Migraine', 
        'High Cholesterol', 'Anemia', 'Arthritis', 'Eczema', 
        'Chronic Bronchitis', 'Heart Disease'
    ]),
    unnest(ARRAY[
        TIMESTAMP '2015-03-10 00:00:00', TIMESTAMP '2018-06-20 00:00:00', TIMESTAMP '2010-08-12 00:00:00',
        TIMESTAMP '2019-01-01 00:00:00', TIMESTAMP '2020-07-08 00:00:00', TIMESTAMP '2012-11-25 00:00:00',
        TIMESTAMP '2017-04-18 00:00:00', TIMESTAMP '2019-10-30 00:00:00', TIMESTAMP '2013-05-22 00:00:00', 
        TIMESTAMP '2021-06-10 00:00:00'
    ]),
    unnest(ARRAY[
        TIMESTAMP '2020-05-15 00:00:00', NULL, TIMESTAMP '2016-10-05 00:00:00', NULL, NULL,
        TIMESTAMP '2018-09-10 00:00:00', NULL, TIMESTAMP '2022-01-15 00:00:00', NULL, NULL
    ])
FROM "Patients";

-- Insert Prescriptions for each Patient
INSERT INTO "Prescriptions" ("PatientId", "MedicineName", "Dosage", "Instructions", "PrescriptionDate")
SELECT 
    "Id", 
    unnest(ARRAY[
        'Lisinopril', 'Metformin', 'Albuterol Inhaler', 'Sumatriptan', 'Atorvastatin', 
        'Ferrous Sulfate', 'Ibuprofen', 'Hydrocortisone Cream', 'Prednisone', 'Aspirin'
    ]),
    unnest(ARRAY[
        '10mg', '500mg', '90 mcg', '50mg', '20mg', '325mg', '400mg', '2%', '5mg', '81mg'
    ]),
    unnest(ARRAY[
        'Take once daily in the morning',
        'Take with meals twice daily',
        'Use as needed for asthma attacks',
        'Take at onset of migraine',
        'Take once daily at night',
        'Take with vitamin C once daily',
        'Take every 6 hours as needed for pain',
        'Apply twice daily to affected area',
        'Take in tapering doses as prescribed',
        'Take once daily for heart protection'
    ]),
    unnest(ARRAY[
        TIMESTAMP '2023-04-15 00:00:00', TIMESTAMP '2023-03-10 00:00:00', TIMESTAMP '2023-01-25 00:00:00', 
        TIMESTAMP '2023-02-05 00:00:00', TIMESTAMP '2023-03-20 00:00:00', TIMESTAMP '2023-05-15 00:00:00', 
        TIMESTAMP '2023-02-28 00:00:00', TIMESTAMP '2023-04-10 00:00:00', TIMESTAMP '2023-05-01 00:00:00', 
        TIMESTAMP '2023-03-15 00:00:00'
    ])
FROM "Patients";

-- Insert Examinations for each Patient
INSERT INTO "Examinations" ("PatientId", "ExaminationType", "ExaminationDateTime", "Notes")
SELECT 
    "Id", 
    unnest(ARRAY[
        'Blood Pressure Check', 'Diabetes Checkup', 'Pulmonary Function Test', 
        'Neurological Exam', 'Lipid Panel Test', 'Iron Level Test', 'Joint Examination', 
        'Skin Examination', 'Respiratory Function Test', 'Cardiology Exam'
    ]),
    unnest(ARRAY[
        TIMESTAMP '2023-06-01 10:30:00', TIMESTAMP '2023-06-02 11:00:00', TIMESTAMP '2023-06-03 09:45:00',
        TIMESTAMP '2023-06-04 15:20:00', TIMESTAMP '2023-06-05 08:10:00', TIMESTAMP '2023-06-06 13:30:00',
        TIMESTAMP '2023-06-07 14:50:00', TIMESTAMP '2023-06-08 10:15:00', TIMESTAMP '2023-06-09 09:00:00', 
        TIMESTAMP '2023-06-10 16:00:00'
    ]),
    unnest(ARRAY[
        'Patient showed signs of hypertension control',
        'Blood sugar levels under control',
        'Mild asthma symptoms noted',
        'Possible triggers for migraines discussed',
        'Cholesterol levels slightly high',
        'Iron deficiency under control',
        'Mild arthritis symptoms noted',
        'Eczema mostly resolved',
        'Bronchitis symptoms persisting',
        'Heart health in stable condition'
    ])
FROM "Patients";
