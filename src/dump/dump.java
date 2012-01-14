import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.util.Random;

import javax.crypto.Cipher;
import javax.crypto.CipherInputStream;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.PBEParameterSpec;

public class dump {

	/**
	 * @param args
	 */
	public static void main(String[] args) {

		System.out.println("[*] Dump.Jar - Minecraft Password Recovery Tool");
		System.out.println("[*] ");
		System.out
				.println("[*] This Tool is Granted to you AS IS, without any implied support or warranty");
		System.out
				.println("[*] The Author of this tool is not Responsible for any misuse or loss of information");
		System.out
				.println("[*] that may be caused by this tool, use at your own discretion");
		System.out.println("[*] ");
		System.out
				.println("[*] This Tool is For Legal Use only. And my only be used for Recovering your Own Lost");
		System.out
				.println("[*] Information Stored in minecrafts's lastLogin File. Any other use is strictly forbidden");
		System.out.println("[*] ");
		System.out
				.println("[*] If you Do not Agree to these Terms Halt this Tool Now and Remove from your Harddrive");
		System.out
				.println("[*] You have 30 seconds from the time of this output to halt if you do not agree with the terms");
		System.out.println("[*] ");
		try {
			Thread.sleep(30000);
		} catch (InterruptedException e) {

		}
		System.out.println("[*] Starting.....");
		System.out.println("[*] ");
		System.out.println("[*] Attempting To Dump Login File at "
				+ getDirectory("minecraft", getOS()).getPath());
		if (DumpContents()) {
			System.out
					.println("[*] Dump successful! look for a lastLogin.dmp in your minecraft folder, ");
			System.out
					.println("[*] Then use a tool like eraser to securly delete the file....");
		} else {
			System.out
					.println("[*] Dump failed! No idea why, check the trace. ");
		}
		System.out.println("[*] ");
	}

	private static Boolean DumpContents() {
		try {
			File Login = new File(getDirectory("minecraft", getOS()),
					"lastlogin");
			Cipher cipher = getCipher(2, "passwordfile");
			DataInputStream DatIS;
			if (cipher != null)
				DatIS = new DataInputStream(new CipherInputStream(
						new FileInputStream(Login), cipher));
			else {
				DatIS = new DataInputStream(new FileInputStream(Login));
			}
			FileWriter fstream = new FileWriter(getDirectory("minecraft",
					getOS()) + "/lastlogin.dmp");
			BufferedWriter out = new BufferedWriter(fstream);
			out.write(DatIS.readUTF() + "\n");
			out.write(DatIS.readUTF() + "\n");
			out.close();
			DatIS.close();

			return true;
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
	}

	private static Cipher getCipher(int mode, String password) throws Exception {
		Random random = new Random(43287234L);
		byte[] salt = new byte[8];
		random.nextBytes(salt);
		PBEParameterSpec pbeParamSpec = new PBEParameterSpec(salt, 5);

		SecretKey pbeKey = SecretKeyFactory.getInstance("PBEWithMD5AndDES")
				.generateSecret(new PBEKeySpec(password.toCharArray()));
		Cipher cipher = Cipher.getInstance("PBEWithMD5AndDES");
		cipher.init(mode, pbeKey, pbeParamSpec);
		return cipher;
	}

	public static File getDirectory(String applicationName, OS osType) {

		String userHome = System.getProperty("user.home", ".");
		File Directory;
		switch (osType.ordinal()) {
		case 1:
		case 2:
			Directory = new File(userHome, '.' + applicationName + '/');
			break;
		case 3:
			String applicationData = System.getenv("APPDATA");
			if (applicationData != null)
				Directory = new File(applicationData, "." + applicationName
						+ '/');
			else
				Directory = new File(userHome, '.' + applicationName + '/');
			break;
		case 4:
			Directory = new File(userHome, "Library/Application Support/" + applicationName);
			break;
		default:
			Directory = new File(userHome, applicationName + '/');
			break;
		}

		return Directory;
	}

	private static OS getOS() {
		String OsType = System.getProperty("os.name").toLowerCase();
		if (OsType.contains("win"))
			return OS.Windows;
		if (OsType.contains("mac"))
			return OS.MacOs;
		if (OsType.contains("solaris"))
			return OS.Solaris;
		if (OsType.contains("sunos"))
			return OS.Solaris;
		if (OsType.contains("linux"))
			return OS.Linux;
		if (OsType.contains("unix"))
			return OS.Linux;
		return OS.Unknown;
	}

	private static enum OS {
		Linux, Solaris, Windows, MacOs, Unknown;
	}
}
