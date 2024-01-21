open Google.OrTools.LinearSolver

// Define the solver
let solver = Solver.CreateSolver("SimpleLinearProgramming", "GLOP_LINEAR_PROGRAMMING")

// Define variables
let x = solver.MakeNumVar(0.0, double.PositiveInfinity, "x")
let y = solver.MakeNumVar(0.0, double.PositiveInfinity, "y")

// Define constraints
solver.Add(2.0 * x + 1.0 * y <= 20.0)
solver.Add(1.0 * x + 2.0 * y <= 30.0)

// Define objective function
let objective = solver.Objective()
objective.SetCoefficient(x, 3.0)
objective.SetCoefficient(y, 4.0)
objective.SetMaximization()

// Solve the problem
let resultStatus = solver.Solve()

// Check if a solution exists
if resultStatus = Solver.ResultStatus.OPTIMAL then
    printfn "Solution Found:"
    printfn "x = %f" (x.SolutionValue())
    printfn "y = %f" (y.SolutionValue())
else
    printfn "No solution found."
