﻿Homework

# ASP NET Core 3 Homework
練習 ASP․NET Core Web API 與 Entity Framework Core 的整合開發
作業內容如下：
* 請以 ContosoUniversity 資料庫為主要資料來源
* 須透過 DB First 流程建立 EF Core 實體資料模型
* 須對資料庫進行版控 (使用資料庫移轉方式)
* 須對每一個表格設計出完整的 CRUD 操作 APIs
* 針對 Departments 表格的 CUD 操作需用到預存程序
* 請在 CoursesController 中設計 vwCourseStudents 與 vwCourseStudentCount 檢視表的 API 輸出
* 請用 Raw SQL Query 的方式查詢 vwDepartmentCourseCount 檢視表的內容
* 請修改 Course, Department, Person 表格，新增 DateModified 欄位(datetime)，並且這三個表格的資料透過 Web API 更新時，都要自動更新該欄位為更新當下的時間 (請新增資料庫移轉紀錄)
* 請修改 Course, Department, Person 表格欄位，新增 IsDeleted 欄位 (bit)，且讓所有刪除這三個表格資料的 API 都不能真的刪除資料，而是標記刪除即可，標記刪除後，在 GET 資料的時候不能輸出該筆資料。(請新增資料庫移轉紀錄)

# Steps
## step 1: ContosoUniversity DB
建立DB並匯入資料
## step 2: Using EF Core Power Tools 
 建立ASPNETCoreHW1_DBFirst專案,透過EF Core Power Tools對ContosoUniversity DB建立 EF Core 實體資料模型

## step 3: Using NET Core CLI to build ASP NET Core Project 
* 建立ASPNETCoreWebAPIHW1專案
```bat
dotnet new webapi -n ASPNETCoreWebAPIHW1 
cd ASPNETCoreWebAPIHW1
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.4
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.4
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 3.1.4
code .
```
 * 把建立在Models下檔案整個資料夾複製搬動到ASPNETCoreWebAPIHW1內
 ```bat
dotnet ef migrations add init
dotnet ef database update -v

```
## step 4: Git
* 建立Git版控,增加.gitignore

## step 5: EF Core Migration Update
* 修改 Course, Department, Person 表格，新增 DateModified 欄位(datetime)
```dash
cd ASPNETCoreWebAPIHW1
dotnet ef migrations add addDateModified
dotnet ef migrations script addDateModified
dotnet ef database update addDateModified
```

* 修改 Course, Department, Person 表格欄位，新增 IsDeleted 欄位 (bit)
```dash
cd ASPNETCoreWebAPIHW1
dotnet ef migrations add addIsDeleted
dotnet ef migrations script addIsDeleted
dotnet ef database update addIsDeleted
```

## step 6: CRUD
* 編輯CRUD Code
