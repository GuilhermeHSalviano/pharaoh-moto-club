import { createContext } from "react";
import type { Claims } from "../types/globalTypes";

export const ClaimsContext = createContext<Claims|undefined>(undefined);