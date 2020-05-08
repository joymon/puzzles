import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class XORStrings {
  public static void main(String[] args ){
          System.out.println(stringsXOR("10101",
                                        "00101"));       
  }
  public static String stringsXOR(String s, String t) {
        String res = new String("");
        for(int i = 0; i < s.length(); i++) {
            if(s.charAt(i) == t.charAt(i))
                res = "0";
            else
                res = "1";
        }

        return res;
  }
}
