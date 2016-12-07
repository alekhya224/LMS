Alter table EmployeeContactDetails 
Add RefEmpId int not null

ALTER TABLE [dbo].[EmployeeContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_EmpDetails_EmployeeContactDetails] FOREIGN KEY([RefEmpId])
REFERENCES [dbo].[EmployeeDetails] ([Id])
GO