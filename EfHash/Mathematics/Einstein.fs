module EfHash.Mathematics.Einstein

open MathNet.Numerics
open Tensor

type Summand =
  | Numeric of float array
  | Many of float array * Summand
